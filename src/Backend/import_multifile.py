import json, os
from elasticsearch import Elasticsearch
es = Elasticsearch([{'host': 'localhost', 'port': '9200'}])
directory = './probas/'


for filename in os.listdir(directory):

    if filename.endswith(".json"):
        try:
            f = open(directory + filename)
            print("found: " + filename)
            docket_content = f.read()
            # Send the data into es
            es.index(index='probas', ignore=400, doc_type='docket', body=json.loads(docket_content))
        except FileNotFoundError:
            print("not found: " + filename)
