package main

import (
	"fmt"
	"net/http"
)

func main() {
	fmt.Println("Hello World")

	http.HandleFunc("/main", sayHello)

	http.ListenAndServe(":8080", nil)
}

func sayHello(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "hello!")
}
