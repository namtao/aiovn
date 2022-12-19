# importing pandas module
import pandas as pd

# making data frame
data = pd.read_csv("https://media.geeksforgeeks.org/wp-content/uploads/nba.csv")

# calling head() method
# storing in new variable
data_top = data.head(10)

# display
print(data_top)
