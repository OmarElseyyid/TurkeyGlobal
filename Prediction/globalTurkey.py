# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""

import pandas as pd
import numpy as np
import matplotlib.pyplot as plt 
from sklearn.linear_model import LinearRegression
from sklearn.metrics import r2_score
from sklearn.preprocessing import PolynomialFeatures
from sklearn.ensemble import RandomForestRegressor
from sklearn import preprocessing
import pyodbc
veriler=pd.read_excel("global_turkey.xlsx")

#Encoder:Kategorik -> Numeric

productCategory=veriler.iloc[:,0:1].values
#1,2,3 :LabelEncoder() 
le=preprocessing.LabelEncoder()
productCategory[:,0]=le.fit_transform(veriler.iloc[:,0])

Category=pd.DataFrame(data=productCategory, index=range(54),columns=["productCategory"])
stock=veriler.iloc[:,1:2].values
stocks=pd.DataFrame(data=stock, index=range(54),columns=["Stock"])
y=veriler.iloc[:,2:3]
Y=y.values
x=pd.concat([Category,stocks],axis=1)
X=x.values




rf_reg=RandomForestRegressor(n_estimators=10,random_state=0)
rf_reg.fit(X,Y.ravel())

print('Random Forest R2 degeri')
print(r2_score(Y, rf_reg.predict(X)))
urun=int(input("Computer : 0, Phone : 1,Refrigerator : 2 : "))
adet=int(input("Stok miktarını giriniz : "))
tahmin=rf_reg.predict([[urun,adet]])

birim=int(tahmin)/adet
print("Toplam Fiyat : ",int(tahmin))
print("Önerilen birim fiyat : ",int(birim))
db = pyodbc.connect(
    'Driver={SQL Server};'
    'Server=.\;'
    'Database=global;'
    'Trusted_Connection=True;'
)
imlec = db.cursor()
komut = 'INSERT INTO pricePredict VALUES(?,?,?,?)'
veriler = (int(urun),int(adet),int(birim),int(tahmin))
sonuc = imlec.execute(komut,veriler)
db.commit()