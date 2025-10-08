import requests
import json



class Post():

    @staticmethod 
    def save() -> None:
        url: str = "http://localhost:151/api/save/add"
        file_path: str = r"C:\Users\jorge\Desktop\POKEMON HG.sav"

        with open(file_path, "rb") as f:
            files = {"saveFile": f} 
            response = requests.post(url, files=files)

        print(response.status_code)
        print(response.json()["message"])



    @staticmethod
    def pkmn() -> None:
        url: str = r"http://localhost:151/api/pkmn/add"
        filePath: str = r".utils\json\1746893822.json"
        with open(filePath, "r") as body:
            body = json.load(body)
            print(body)
        response = requests.post(url, json=body)
        try:
            print(response.status_code)
            data = response.json()
            print(data["message"])
        except Exception as e:
            print(f"Error: {response.status_code} - {e}")


if __name__ == '__main__':
    Post.save()
