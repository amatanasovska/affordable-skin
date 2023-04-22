import re
import pandas as pd

class InvalidPriceException(Exception):
    
    def __init__(self, *args: object) -> None:
        super().__init__("Invalid number")

def get_numbers_only(string):
    match = re.search(r'\d+\.*\d*', string)
    if match:
        number = match.group()
        return number
    
    raise InvalidPriceException()

def remove_point(string):
    return "".join(string.split("."))

for csv_file in ("yeppeuda_tiam.csv","coslovemetics_tiam.csv"):
    df = pd.read_csv(csv_file)
    df['price'] = list(map(get_numbers_only,df['price']))
    df['price'] = list(map(remove_point,df['price']))
    
    df.to_csv(f"{csv_file[:-4]}_cleaned.csv")
