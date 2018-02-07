#coding=utf-8

'''
autor: c0ny1
date: 2018-2-7
'''

from flask import Flask, request, url_for, render_template, redirect
from xml.dom import minidom

app = Flask(__name__)
app.config['DEBUG'] = True

USERNAME = 'admin' # 账号
PASSWORD = 'admin' # 密码

@app.route("/")
def home():
    return render_template("index.html")

@app.route("/doLogin", methods=['POST', 'GET'])
def doLogin():
    result = None
    try:
        DOMTree = minidom.parseString(request.data)
        username = DOMTree.getElementsByTagName("username")
        username = username[0].childNodes[0].nodeValue
        password = DOMTree.getElementsByTagName("password")
        password = password[0].childNodes[0].nodeValue
    
        if username == USERNAME and password == PASSWORD:
            result = "<result><code>%d</code><msg>%s</msg></result>" % (1,username)
        else:
            result = "<result><code>%d</code><msg>%s</msg></result>" % (0,username)
    except Exception,e:
        result = "<result><code>%d</code><msg>%s</msg></result>" % (3,e.message)
	
    return result,{'Content-Type': 'text/xml;charset=UTF-8'}

def prn_obj(obj):
    print '\n'.join(['%s:%s' % item for item in obj.__dict__.items()])

if __name__ == "__main__":
    app.run()
	


