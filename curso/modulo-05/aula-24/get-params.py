curve = {
    "Primo": """00:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:
    ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:ff:fe:ff:
    ff:fc:2f""",
    
    "A": """0""",

    "B": """7""",

    "G": """04:79:be:66:7e:f9:dc:bb:ac:55:a0:62:95:ce:87:
    0b:07:02:9b:fc:db:2d:ce:28:d9:59:f2:81:5b:16:
    f8:17:98:48:3a:da:77:26:a3:c4:65:5d:a4:fb:fc:
    0e:11:08:a8:fd:17:b4:48:a6:85:54:19:9c:47:d0:
    8f:fb:10:d4:b8""",
}

for hex in curve:
    hexValue = curve[hex].replace("\n", "").replace(":", "").replace(" ", "")
    if hex == "G":
        xy = hexValue[2:]
        x = xy[0:int(len(xy) / 2)]
        y = xy[:int(len(xy) / 2)]
        xNumber = int(x, 16)
        yNumber = int(y, 16)
        print(f'G: ({xNumber},{yNumber})')
    else:
        print(f'{hex}: {int(hexValue, 16)}')