import pandas as pd
import numpy as np
from DBUtils import *
from IPython.display import display
from tabulate import tabulate

df = pd.read_sql('select top(1) id from hs_nguoicc', connectDB())

# display(df.style)

print(tabulate(df, headers = 'keys', tablefmt = 'psql'))