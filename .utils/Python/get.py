import requests

response = requests.get('http://localhost:151/api/info')

try:
    data = response.json()
    print(data)
except Exception as e:
    print(f"Error: {response.status_code} - {e}")