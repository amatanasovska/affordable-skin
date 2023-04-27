from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.common.exceptions import NoSuchElementException,StaleElementReferenceException
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

from datetime import date

import pandas as pd

def explore_page(driver, data):
    elements = driver.find_elements_by_css_selector("#main > div > div > div.product-style.product-style-7 > ul > li")
    for element in elements:
        element_dict = dict()

        product_image = element.find_element_by_css_selector(".image-product > a > img").get_attribute("src")
        element_dict['image'] = product_image
        # element_dict['stock_info'] = "null"
        element_dict['title'] = element.find_element_by_css_selector(".product-desc .woocommerce-loop-product__title .product-name").text
        try:
            element_dict['price'] = element.find_element_by_css_selector(".price > ins").text
        except NoSuchElementException:
            element_dict['price'] = element.find_element_by_css_selector(".price .amount").text
        element_dict['date'] = date.today()
        element_dict['brand'] = brand
        element_dict['link'] = element.find_element_by_css_selector("div > div.product-top > div.image-product > a").get_attribute("href")
        data.append(element_dict)

data = []
driver = webdriver.Chrome(ChromeDriverManager().install())

driver.get("https://olpeo.mk/brendovi/")

brand_list = driver.find_element_by_css_selector("#post-15746 > div > div > div > div > main > div > div > div > div > div > div > div > div > div")
links = list(set(map(lambda link_b: link_b.get_attribute("href"),
    brand_list.find_elements_by_css_selector(".yith-wcbr-same-heading-box > ul > li > a:nth-child(1)"))))

for link in links:
    driver.get(link)
    pages_links = []
    pages = []
    pages_links = []
    try:
        pages_list = driver.find_element_by_css_selector("#main > div > div > nav > ul")
        pages = pages_list.find_elements_by_css_selector("li > a")
        pages_links = list({pglink for pglink in list(map(lambda page_l: page_l.get_attribute("href"),pages)) if pglink!=None})
    except NoSuchElementException:
        pass

    try:
        brand = driver.find_element_by_css_selector("#page > div.side-breadcrumb > div > div > div > div > h1").text
    #     if "Резултати" in brand:
    #         brand = brand.split("Резултати од пребарувањето за: “")[-1][:-1]
        brand = brand.lower()
    except NoSuchElementException:
        pass
    explore_page(driver,data)

    for page in pages_links:
        driver.get(page)
        explore_page(driver, data)

df = pd.DataFrame(data)
df.to_csv("olpeo_all_products.csv",index=False)

driver.quit()