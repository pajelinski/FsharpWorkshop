module MyStack

type MyStack<'a> = MyStack of ('a list * int)
type MyStackOverflowException() = inherit System.Exception()
type MyStackUnderflowException() = inherit System.Exception()

let private unwrap myStack = 
    myStack
    |> fun (MyStack(stackList, capacity)) -> (stackList, capacity)

let private (|StackOverflow|_|) (stackList: int list, capacity: int) = 
    if stackList.Length >= capacity then Some StackOverflow else None

let private (|StackUnderflow|_|) stackList = 
    if stackList |> List.isEmpty then Some StackUnderflow else None

let create capacity = 
    if capacity < 0 then raise (System.ArgumentException())
    else ([], capacity) |> MyStack

let size stack = 
    stack |> unwrap |> fun (_, capacity) -> capacity

let push item stack =
    let stackList, capacity = stack |> unwrap

    match (stackList, capacity) with
        | StackOverflow -> raise (MyStackOverflowException())
        | _ -> (item::stackList, capacity) |> MyStack

let pop stack = 
    let stackList, capacity = stack |> unwrap

    match stackList with
        | StackUnderflow -> raise (MyStackUnderflowException())
        | _ -> (stackList.Head , (stackList.Tail, capacity) |> MyStack)
