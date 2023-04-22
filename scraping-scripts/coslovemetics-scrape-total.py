from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException,StaleElementReferenceException
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

from datetime import date

import pandas as pd

def explore_page(driver, data):
    elements = driver.find_elements_by_css_selector("#page > div.container.mt-4 > div > div.col-md-12.col-12.col-xl-9.my-3.mx-auto > ul > div")
    for element in elements:
        element_dict = dict()

        product_image = element.find_element_by_css_selector("img").get_attribute("src")
        element_dict['image'] = product_image
        element_dict['stock_info'] = "null"
        element_dict['title'] = element.find_element_by_css_selector(".woocommerce-loop-product__title").text
        try:
            element_dict['price'] = element.find_element_by_css_selector(".price > ins").text
        except NoSuchElementException:
            element_dict['price'] = element.find_element_by_css_selector("a.woocommerce-LoopProduct-link.woocommerce-loop-product__link > span > span").text
        element_dict['date'] = date.today()
        element_dict['brand'] = brand
        element_dict['link'] = element.find_element_by_css_selector("#page > div.container.mt-4 > div > div.col-md-12.col-12.col-xl-9.my-3.mx-auto > ul > div > div > div > a.woocommerce-LoopProduct-link.woocommerce-loop-product__link").get_attribute("href")
        data.append(element_dict)

data = []
driver = webdriver.Chrome(ChromeDriverManager().install())

driver.get("https://coslovemetics.mk/brands/")

brand_list = driver.find_element_by_css_selector("#page > div.container.my-5")
links = list(set(map(lambda link_b: link_b.get_attribute("href"),
    brand_list.find_elements_by_css_selector("#page > div.container.my-5 > div > div> div > a"))))

for link in links:
    driver.get(link)
    pages_links = []
    pages = []
    pages_links = []
    try:
        pages_list = driver.find_element_by_css_selector("#page > div.container.mt-4 > div > div.col-md-12.col-12.col-xl-9.my-3.mx-auto > nav > ul")
        pages = pages_list.find_elements_by_css_selector("li > a")
        pages_links = list({pglink for pglink in list(map(lambda page_l: page_l.get_attribute("href"),pages)) if pglink!=None})
    except NoSuchElementException:
        pass

    
    
    brand = driver.find_element_by_css_selector("#page > div.archive-header-bg-image > div > header > h1").text
    if "Резултати" in brand:
        brand = brand.split("Резултати од пребарувањето за: “")[-1][:-1]
    print(brand)
    explore_page(driver,data)

    for page in pages_links:
        driver.get(page)
        explore_page(driver, data)

df = pd.DataFrame(data)
df.to_csv("coslovemetics_all_products.csv",index=False)

driver.quit()