import os
from subprocess import call

print(os.getcwd())

def open_file():
        call(["python", os.getcwd() + "\\inference_classifier.py"])
        

open_file()