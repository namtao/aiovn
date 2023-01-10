import inquirer
from getpass4 import getpass
from inquirer.themes import Default

password = getpass('Password: ')

print(password)


def config_cmd():
    questions = [
        inquirer.Checkbox(
            "interests",
            message="What are you interested in?",
            choices=["Computers", "Books", "Science", "Nature", "Fantasy", "History"],
            default=["Computers", "Books"],
        ),
    ]

    class WorkplaceFriendlyTheme(Default):
        """Custom theme replacing X with Y and o with N"""

        def __init__(self):
            super().__init__()
            self.Checkbox.selected_icon = "Y"
            self.Checkbox.unselected_icon = "N"

    answers = inquirer.prompt(questions, theme=WorkplaceFriendlyTheme())

    print(answers)
    
config_cmd()

