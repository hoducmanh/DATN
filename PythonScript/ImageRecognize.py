import cv2
from cvzone.HandTrackingModule import HandDetector
from cvzone.ClassificationModule import Classifier
import numpy as np
import math
import socket
import time
 
cap = cv2.VideoCapture(0)
detector = HandDetector(maxHands=1)
classifier = Classifier("Model/keras_model.h5", "Model/labels.txt")
host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))
 
offset = 20
imgSize = 300
 
folder = "./"
counter = 0
 
#labels = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"]
labels = ["A","B","C","D"]
timeOut = time.time()

while True:
    try:
        success, img = cap.read()
        imgOutput = img.copy()
        hands, img = detector.findHands(img)
        if hands:
            hand = hands[0]
            x, y, w, h = hand['bbox']
    
            imgWhite = np.ones((imgSize, imgSize, 3), np.uint8) * 255
            imgCrop = img[y - offset:y + h + offset, x - offset:x + w + offset]
    
            imgCropShape = imgCrop.shape
    
            aspectRatio = h / w
    
            if aspectRatio > 1:
                k = imgSize / h
                wCal = math.ceil(k * w)
                imgResize = cv2.resize(imgCrop, (wCal, imgSize))
                imgResizeShape = imgResize.shape
                wGap = math.ceil((imgSize - wCal) / 2)
                imgWhite[:, wGap:wCal + wGap] = imgResize
                prediction, index = classifier.getPrediction(imgWhite, draw=False) #gọi mô hình dự đoán hand sign với đầu vào là ảnh được xử lý
                print(prediction, index) # prediction trả về 1 list các xác suất ký hiệu sẽ rơi vào vào chữ nào, index trả về chỉ mục của phần tử lớn nhất trong list xác suất đó
    
            else:
                k = imgSize / w
                hCal = math.ceil(k * h)
                imgResize = cv2.resize(imgCrop, (imgSize, hCal))
                imgResizeShape = imgResize.shape
                hGap = math.ceil((imgSize - hCal) / 2)
                imgWhite[hGap:hCal + hGap, :] = imgResize
                prediction, index = classifier.getPrediction(imgWhite, draw=False)
    
            cv2.rectangle(imgOutput, (x - offset, y - offset-50),
                        (x - offset+90, y - offset-50+50), (255, 0, 255), cv2.FILLED) # vẽ hình chữ nhật tại vị trí chỉ định
            cv2.putText(imgOutput, labels[index], (x, y -26), cv2.FONT_HERSHEY_COMPLEX, 1.7, (255, 255, 255), 2)
            print(labels[index])
            cv2.rectangle(imgOutput, (x-offset, y-offset),
                        (x + w+offset, y + h+offset), (255, 0, 255), 4)
            cv2.imshow("ImageCrop", imgCrop)
            cv2.imshow("ImageWhite", imgWhite)
            if(time.time() - timeOut > 0.5): 
                sock.sendall(labels[index].encode("UTF-8"))
                receivedData = sock.recv(1024).decode("UTF-8")
                timeOut = time.time()   
        cv2.imshow("Image", imgOutput)
        cv2.waitKey(1)


    except:
        pass