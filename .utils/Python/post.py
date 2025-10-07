import requests

url = "http://localhost:151/api/save/add"
file_path = r"C:\Users\jorge\Desktop\POKEMON HG.sav"

with open(file_path, "rb") as f:
    files = {"saveFile": f}  # o nome 'saveFile' deve bater com o field do multer
    response = requests.post(url, files=files)

print(response.status_code)
print(response.json()["message"])
