import pandas as pd
import pyodbc 

cnxn = pyodbc.connect('Driver={ODBC Driver 17 for SQL Server};Server=(localdb)\mssqllocaldb;Database=AffordableSkin;Trusted_Connection=yes')
# Connect to the database

def insert_seller(name_seller):
    cursor = cnxn.cursor()
    sql = "INSERT INTO Seller (Name) VALUES (?)"
    values = (name_seller)
    cursor.execute(sql, values)
    cursor.commit()
    cursor.close()

def transform_shop(csv_file):
    # Read the CSV file
    df = pd.read_csv(csv_file)

    # Map the columns
    column_mapping_product = {'image': 'image', 'Name':'title'}
    column_mapping_product_price = {'date': 'date', 'price': 'price'}

    name_seller = csv_file.split("_")[0]
    cursor = cnxn.cursor()

    sql = f"Select S.Id from Seller S where S.Name = '{name_seller}'"
    cursor.execute(sql)

    # fetch the results
    result = cursor.fetchall()[0]
    seller_id = result[0]


    for index, row in df.iterrows():
        sql = "INSERT INTO Product ({}) VALUES (?, ?, ?)".format(', '.join(column_mapping_product.keys())+",SellerId")
        values = tuple([row[column_mapping_product[key]] for key in column_mapping_product.keys()] + [seller_id])
        cursor.execute(sql, values)
        sql = f"Select P.Id from Product P where P.Name = ?"
        cursor.execute(sql,row['title'])
        result = cursor.fetchall()[0]
        product_id = result[0]
        sql = "INSERT INTO ProductPrice ({}) VALUES (?, ?, ?)".format('ProductId,' + ', '.join(column_mapping_product_price.keys()))
        values = tuple([product_id] + [row[column_mapping_product_price[key]] for key in column_mapping_product_price.keys()])
        cursor.execute(sql, values)

    cnxn.commit()

    cursor.close()
    cnxn.close()

if __name__=="__main__":
    # insert_seller("yeppeuda")
    transform_shop("yeppeuda_tiam.csv")