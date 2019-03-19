package main

import (
	"fmt"
	"bytes"
)

func printTypeValue(slist ...interface{}) string {
	
	// 字节缓冲作为快速字符串连接
	var b bytes.Buffer

	for _,s := range slist{

		// 将 interface{} 类型格式化为字符串
		str := fmt.Sprintf("%v",s)

		//类型的描述
		var typeString string

		switch s.(type) {
		case bool:
			typeString ="bool"
		case string :
			typeString ="string"
		case int :
			typeString ="int"
			default :
			typeString="unknown"
		}

		b.WriteString("value: ")
		b.WriteString(str)
		b.WriteString(" type: ")
		b.WriteString(typeString)
		b.WriteString("\n")
	}
	return b.String();
}

func main()  {
	
	fmt.Println(printTypeValue(100,"str",true,3.205))
}