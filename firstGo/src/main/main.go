package main

import (
	// "config"
	"fmt"
	"sync"
)

func main() {
	// config.LoadConfig()

	// welcome := []string{"hello","world"}
	// change(welcome...)
	// fmt.Println(welcome)

	// number := 589
	// sqrch :=make(chan int)
	// cubech := make(chan int)
	// go calcSquares(number,sqrch)
	// go calcCubes(number,cubech)
	
	// squares,cubes := <- sqrch,<- cubech
	// fmt.Println("Final output ",squares+cubes)

	
	var w sync.WaitGroup
	var m sync.Mutex
	for i:=0;i<1000;i++{
		w.Add(1)
		go increment(&w,&m)
	}
	w.Wait()
	fmt.Println("final value of x ",x)





}

// func change(s ...string){
// 	s[0]="GO"
// 	s=append(s,"playground")
// 	fmt.Println(s)
// }

func calcSquares(number int ,squareop chan int){
	sum := 0
	for number !=0{
		digit := number %10
		sum += digit * digit
		number /=10
	}
	squareop <- sum
}

func calcCubes(number int,cubeop chan int){
	sum := 0
	for number!=0 {
		digit := number % 10
		sum += digit * digit *digit
		number /=10
	}
	cubeop <- sum
}

var x=0
// func increment(wg *sync.WaitGroup){
// 	x = x+1
// 	wg.Done()
// }

func increment(wg *sync.WaitGroup,m *sync.Mutex){
	m.Lock()
	x = x+1
	m.Unlock()
	wg.Done()
}
