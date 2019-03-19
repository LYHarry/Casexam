package main

import (
	"fmt"
	s "strings"
	"bufio"
	"os"
)


var p = fmt.Println

func  main()  {
	// p("Contains",s.Contains("test","es"))
	// p("Count",s.Count("test","t"))
	// p("ToUpper",s.ToUpper("test"))

	scanner := bufio.NewScanner(os.Stdin)
	for scanner.Scan() {
		 ucl := s.ToUpper(scanner.Text())
		 fmt.Println(ucl)
	}

	if err := scanner.Err();err!=nil{
		fmt.Fprintln(os.Stderr,"error",err)
		os.Exit(1)
	}
}