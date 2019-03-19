package main

import (
	"fmt"
	"time"
)

func main()  {
	
	ticker := time.NewTicker(time.Millisecond*1000)
	go func(){
		for t := range ticker.C {
			fmt.Println("Tick at: ",t)
		}
	}()

	time.Sleep(time.Second * 1000)
	ticker.Stop()
	fmt.Println("Ticker Stop")
}