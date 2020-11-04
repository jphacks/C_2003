import requests
import json
import sys

args = sys.argv
if len(args) == 1:
    text = input()
else :
    text = args[1]



api_base_url = 'https://api.ce-cotoha.com/api/dev/'
client_id = 'c1Ii8iIyLiZSAAUlKMdFR2rp6OCAP590'
client_secret = 'Nvpef6VG0nZO3TzC'
access_token_url = 'https://api.ce-cotoha.com/v1/oauth/accesstokens'

# Token取得
headers = { "Content-Type" : "application/json" }
data = { "grantType":"client_credentials", "clientId":client_id, "clientSecret":client_secret }
r = requests.post(access_token_url, data=json.dumps(data), headers=headers)
bearer_token = r.json()["access_token"]

# ユーザー属性取得
headers = { "Content-Type" : "application/json;charset=UTF-8", "Authorization":"Bearer "+bearer_token }
data = { "sentence":text }
url = api_base_url + "nlp/v1/sentiment"
r = requests.post(url, data=json.dumps(data), headers=headers)
# r = requests.post(url)
jjj = r.json();

if jjj["result"]["sentiment"] == "Negative":
    print(1)
elif jjj["result"]["sentiment"] == "Positive":
    print(2)
else :
    print(1)