import json, os
from elasticsearch import Elasticsearch

es = Elasticsearch(["https://host:token@elasticsearch.z-core.de:443"])

file = open('probas.json', 'r')
lines = file.readlines()

count = 1
for line in lines:
    print('Line: ', count)
    if count > 2167:
        es.index(index='probas', doc_type='docket', ignore=400, body=json.loads(line))
    count += 1
