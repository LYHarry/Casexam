package main
import "fmt"

func  main()  {

	// fmt.Println("go"+"lang");

	// /不是整除
	// fmt.Println("7.2/2.3 = ",7.2/2.3);

	// 数组
	// var a [5]int;
	// fmt.Println("emp:",a);

	// a[4]=100;
	// fmt.Println("set:",a);

	// fmt.Println("len",len(a));

	// var b =[...]string{"a","b","c","df"};
	// fmt.Println("b:",b);

	//切片
	// var nums []int;
	// for i:=0;i<10;i++{
	// 	nums = append(nums ,i ); 
	// 	// fmt.Println("len: %d  cap: %d p: %p ",len(num),cap(num),num);
	// 	fmt.Printf("len: %d  cap: %d pointer: %p\n", len(nums), cap(nums), nums)
	// }

	// var str []string;
	// team := []string{"abc","efg","xyz"};
	// str= append(str,team...);
	// fmt.Println(str);

	// var empty= []int{};

	// fmt.Println(num,str,empty);


	//range 

	// for i,c := range "abcd"{
	// 	fmt.Println(i,c);
	// }


   	//  sum,note := plus(1,2);
	//  fmt.Println(sum,note);
	 
	//  sum =moreParam("e",1,2,3,4,5,6,7,8,9,10);
	//  fmt.Println(sum);

	//递归 阶乘
	fmt.Println(fact(7));


}

func plus(a ,b int )(int,string)  {
   return a+b,"加数";
}

//  ... 只能用于最后一个参数
func moreParam(notes string,nums ...int ,) int {
	sum := 0;
	for _,i := range nums{
		sum += i;
	 }
	 fmt.Println(notes);
	 return sum;
}

func fact(n int) int {
	if(n<=1){
		return 1;
	}
	return n * fact(n-1);
}