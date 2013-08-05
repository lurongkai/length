# -*- coding: utf-8 -*-
"""
Created on Thu Aug 01 18:40:40 2013

@author: wy
"""

import ps


ops = ['+','-']
convertDict = {'m':1}

def getdict(line):
    line = line.strip().split('=')
    for i in range(2):
        line[i] = line[i].strip().split(' ')
    convertDict[line[0][1]] = float(line[1][0])
    
    
def getresult(line):
    p = ps.PorterStemmer()
    if '+' in line:
        line = line.strip().split('+',1)
        return getresult(line[0])+getresult(line[1])
    elif '-' in line:
        line = line.strip().split('-',1)
        return getresult(line[0])-getresult(line[1])
    else:
        line = line.strip().split(' ')
        return float(line[0])*convertDict[p.stem(line[1],0,len(line[1])-1)]
        
if __name__=='__main__':
    with open('input.txt') as f:
        lines = f.readlines()
    with open('output.txt','w') as of:
        of.write('zxzx1135@hotmail.com\n\n')
        for line in lines:
            if not line.strip():
                continue
            if '=' in line:
                getdict(line)
            else:
                of.write('%.2f m\n'%getresult(line))
            
    
        