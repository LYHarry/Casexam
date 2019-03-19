package main

import (
	"fmt"
	"reflect"
	"strings"
)

type order struct {
	ordId, customerId int
	floatId           float32
}

type employee struct {
	name    string
	id      int
	address string
	salary  int
	country string
}

func createQuery(q interface{}) {
	v := reflect.ValueOf(q)
	if v.Kind() != reflect.Struct {
		fmt.Println("unsupported type")
		return
	}
	t := reflect.TypeOf(q).Name()
	var fields, values, f string
	for i := 0; i < v.NumField(); i++ {
		f = v.Type().Field(i).Name
		fields = fmt.Sprintf("%s%s,", fields, f)
		switch k := v.Field(i).Kind(); k {
		case reflect.Int:
			{
				values = fmt.Sprintf("%s%d,", values, v.Field(i).Int())
			}
		case reflect.String:
			{
				values = fmt.Sprintf("%s\"%s\",", values, v.Field(i).String())
			}
		default:
			{
				fmt.Printf("%s type of the %s field of the %s object is not supported\n", k, f, t)
				return
			}
		}
	}
	fields = strings.Trim(fields, ",")
	values = strings.Trim(values, ",")
	query := fmt.Sprintf("insert into %s(%s) values(%s)", t, fields, values)
	fmt.Println(query)
}

func main() {
	o := order{
		ordId:      456,
		customerId: 56,
	}
	createQuery(o)

	e := employee{
		name:    "Naveen",
		id:      565,
		address: "Coimbatore",
		salary:  90000,
		country: "India",
	}
	createQuery(e)

	i := 90
	createQuery(i)
}
