package employee
import (
	"fmt"
)

type employee struct{
	name string
	totalLeaves,leavesTaken int
}

func New(name string ,total,leave int) employee{
	e := employee{name,total,leave};
	return e;
}

// 无重载
// func New() employee{
// 	e := employee{"",0,0};
// 	return e;
// }

func (e employee) LeavesRemaining(){
	fmt.Printf("%s has %d leaves remaining ",e.name,(e.totalLeaves-e.leavesTaken))
}