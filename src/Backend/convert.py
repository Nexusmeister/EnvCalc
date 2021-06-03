import os

directory = './probas/'


for filename in os.listdir(directory):

    if filename.endswith(".json"):
        try:
            f = open(directory + filename)
            print("found: " + filename)
            docket_content = f.read()
            with open('probas.txt', 'a') as file:
                file.write(docket_content+"\n")
        except FileNotFoundError:
            print("not found: " + filename)
