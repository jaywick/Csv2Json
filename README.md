# Csv2Json
Converts a CSV to JSON taking into account inner commas and quotation marks

# Usage

    Csv2Json.exe "c:\path\file.csv"
  
Will create create a JSON file at `c:\path\file.json`

# Example

Consider the following CSV input

    CustomerID, Name, Postcode, Notes
    1000110, Julia Jones,2000,"Likes banana bread with her chai latte, has a dog named ""Junior"""
    1115009, Kayman Rockerfella,2110,"Writes decimal points with commas, so ""$10,00"" is ten bucks to this guy"

And here's the output in JSON

    [
      {
        "CustomerID": "1000110",
        " Name": " Julia Jones",
        " Postcode": "2000",
        " Notes": "Likes banana bread with her chai latte, has a dog named \"Junior\""
      },
      {
        "CustomerID": "1115009",
        " Name": " Kayman Rockerfella",
        " Postcode": "2110",
        " Notes": "Writes decimal points with commas, so \"$10,00\" is ten bucks to this guy"
      }
    ]
