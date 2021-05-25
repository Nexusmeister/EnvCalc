import json, os
from elasticsearch import Elasticsearch

es = Elasticsearch([{'host': 'localhost', 'port': '9200'}])

file = open('probas.json', 'r')
lines = file.readlines()

count = 1
for line in lines:
    print('Line: ', count)
    es.index(index='probas', doc_type='docket', ignore=400, body=json.loads(line))
    count += 1
