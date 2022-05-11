# collection = table
# document = rows

# Trong MongoDB , một cơ sở dữ liệu chỉ được tạo khi nó có nội dung (document) bên trong. 
# Vì vậy lần đầu tiên bạn thực hiện tạo cơ sở dữ liệu cần phải thực hiện 2 bước sau (Tạo collection và Tạo Document) 
# trước khi bạn muốn check xem database có tồn tại không

# MongoDB sẽ tạo ra database mà bạn muốn. 
# Tuy nhiên nếu database đã tồn tại thì Python sẽ tạo ra 1 connection vơi database được chỉ định

# create db
def get_database():
    from pymongo import MongoClient
    import pymongo

    # Provide the mongodb atlas url to connect python to mongodb using pymongo
    # CONNECTION_STRING = "mongodb+srv://<username>:<password>@<cluster-name>.mongodb.net/myFirstDatabase"
    CONNECTION_STRING = "mongodb://localhost:27017/"

    # Create a connection using MongoClient. You can import MongoClient or use pymongo.MongoClient
    client = MongoClient(CONNECTION_STRING)

    # check xem database có tồn tại không?
    # print(client.list_database_names())

    # Create the database for our example (we will use the same database throughout the tutorial
    return client['ADDJ']


# This is added so that many files can reuse the function get_database()
if __name__ == "__main__":

    # Get the database
    dbname = get_database()
    
    # Create table
    mycol = dbname["ThietBi"]
