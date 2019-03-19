package main

import (
	"fmt"
)

func f(from string)  {
	
	for i:=1;i<11;i++{
		fmt.Println(from," : ",i)
	}
}

func main(){

	go f("direct")

	go func(msg string){
		for i:=1;i<11;i++{
			fmt.Println(msg," : ",i)
		}
	}("going")

	var input string
	fmt.Scanln(&input);
	fmt.Println("done");
}