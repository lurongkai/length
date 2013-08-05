#coding=utf8
#tested on python 2.x

def check(data, token):
    if (not token in data):
        if token[:-1] in data:
            return token[:-1]
        elif token[:-2] in data:
            return token[:-2]
        elif token == "feet":
            return "foot"
    return token

def main():
    
    data = {}
    result = ["mailyc@qq.com\n\n"]
    
    lines = open("input.txt", "r").readlines()
    for line in lines:
        if "=" in line:
            other, meter = line.split("=")
            numer, key = other.split()
            denom, me = meter.split()
            data[key] = (float(numer), float(denom))
        elif not line.isspace():
            tokens = []
            for token in line.split():
                token = check(data, token)
                if token in data:
                    numer, denom = data[token]
                    mm = float(tokens.pop())*denom/numer
                    tokens.append(str(round(mm, 2)))
                else:
                    tokens.append(token)
            re = eval(''.join(tokens))
            result.append(str(re) + " m\n")
    
    open("output.txt", "w").write(''.join(result))

if __name__ == "__main__":
    main()
    
