import json, os
from elasticsearch import Elasticsearch

es = Elasticsearch([{'host': 'localhost', 'port': '9200'}])


line = '{"id": "id1", "name": "name1"}'

es.index(index='testIndex', doc_type='docket', ignore=400, body=json.loads(line))
