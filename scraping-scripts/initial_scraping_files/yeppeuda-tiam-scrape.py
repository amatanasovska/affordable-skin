from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException,StaleElementReferenceException
from webdriver_manager.chrome import ChromeDriverManager

from datetime import date

import pandas as pd

data = []
# Create a new instance of the Firefox driver
driver = webdriver.Chrome(ChromeDriverManager().install())

# Navigate to the Yeppeuda homepage
driver.get("https://yeppeuda.mk/c/47/tiam")

pages_list = driver.find_element_by_css_selector("body > main > div.content-wrapper.oh > section > div > div:nth-child(2) > div > div > div > div:nth-child(2) > div > div > nav > ul")
pages = pages_list.find_elements_by_css_selector("li")

final_page = max(list(map(int,pages_list.text.split("\n"))))
page_number = 2
while True:
    elements = driver.find_elements_by_css_selector(".col-md-4.col-xs-6.product.product-grid")

    for element in elements:
        element_dict = dict()

        product_image = element.find_element_by_css_selector("img").get_attribute("src")
        element_dict['image'] = product_image
        try:
            stock_info = element.find_element_by_css_selector(".no-stock-partials")
            element_dict['stock_info'] = stock_info.text
        except NoSuchElementException:
            element_dict['stock_info'] = "AVAILABLE"
        element_dict['title'] = element.find_element_by_css_selector(".product-title").text
        element_dict['price'] = element.find_element_by_css_selector(".price").text
        element_dict['date'] = date.today()
        data.append(element_dict) 

    if page_number<=final_page:
        driver.get(f"https://yeppeuda.mk/c/47/tiam?page={page_number}")
        page_number+=1
    else:
        break

df = pd.DataFrame(data)
df.to_csv("yeppeuda_tiam.csv",index=False)

driver.quit()