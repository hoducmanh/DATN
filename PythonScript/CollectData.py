import cv2
from cvzone.HandTrackingModule import HandDetector
import numpy as np
import math
import time
 
cap = cv2.VideoCapture(0)
detector = HandDetector(maxHands=2)
 
offset = 20
imgSize = 300
 
folder = "./D"
counter = 0
 
while True:
    try: 
        success, img = cap.read()
        hands, img = detector.findHands(img)
        if hands:
            hand = hands[0] 
            x, y, w, h = hand['bbox']
    
            imgWhite = np.ones((imgSize, imgSize, 3), np.uint8) * 255 #tạo ma trận toàn hệ số 1 sau đó nhân với 255 => 1 ảnh trắng 3 màu RGB
            imgCrop = img[y - offset:y + h + offset, x - offset:x + w + offset] # cắt ảnh lấy 1 ma trận con chỉ chứa tay
    
            imgCropShape = imgCrop.shape #trả về hình dáng của ảnh bao gồm chiều dài rộng và số kênh màu
    
            aspectRatio = h / w #tỉ lệ giữa cd và cr
    
            if aspectRatio > 1: #tay quay dọc
                k = imgSize / h 
                wCal = math.ceil(k * w) #lấy chiều có độ dài lớn nhât = 300 và chiều còn lại có độ dài tỉ lệ thuận với độ dài cũ
                imgResize = cv2.resize(imgCrop, (wCal, imgSize)) #resize ảnh
                imgResizeShape = imgResize.shape #lấy shape
                wGap = math.ceil((imgSize - wCal) / 2) #tìm ra độ rộng 2 khoảng trắng 2 bên
                imgWhite[:, wGap:wCal + wGap] = imgResize # đặt ảnh vào giữa ảnh trắng
    
            else: #tay quay ngang
                k = imgSize / w
                hCal = math.ceil(k * h)
                imgResize = cv2.resize(imgCrop, (imgSize, hCal))
                imgResizeShape = imgResize.shape
                hGap = math.ceil((imgSize - hCal) / 2)
                imgWhite[hGap:hCal + hGap, :] = imgResize
    
            cv2.imshow("ImageCrop", imgCrop)
            cv2.imshow("ImageWhite", imgWhite)
    
        cv2.imshow("Image", img)
        key = cv2.waitKey(1) #tạo event input để chụp màn hình
        if key == ord("s"):
            counter += 1
            cv2.imwrite(f'{folder}/Image_{time.time()}.jpg',imgWhite)
            print(counter)
    except:
        pass