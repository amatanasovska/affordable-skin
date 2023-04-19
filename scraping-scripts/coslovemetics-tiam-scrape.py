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
driver.get("https://coslovemetics.mk/product-category/brands/tiam/")

# pages_list = driver.find_element_by_css_selector("#page > div.container.mt-4 > div > div.col-md-12.col-12.col-xl-9.my-3.mx-auto")
pages = driver.find_element_by_css_selector("#page > div.container.mt-4 > div > div.col-md-12.col-12.col-xl-9.my-3.mx-auto > nav")

final_page = max(list(map(int,pages.text.split("\n")[:-1])))

page_number = 2
while True:
    elements = driver.find_elements_by_css_selector(".product")

    for element in elements:
        element_dict = dict()

        product_image = element.find_element_by_css_selector("img").get_attribute("src")
        element_dict['image'] = product_image
        element_dict['stock_info'] = "null"
        element_dict['title'] = element.find_element_by_css_selector(".woocommerce-loop-product__title").text
        element_dict['price'] = element.find_element_by_css_selector(".price > ins").text
        element_dict['date'] = date.today()
        data.append(element_dict) 

    if page_number<=final_page:
        driver.get(f"https://coslovemetics.mk/product-category/brands/tiam/page/{page_number}")
        page_number+=1
    else:
        break
df = pd.DataFrame(data)
df.to_csv("coslovemetics_tiam.csv",index=False)

driver.quit()