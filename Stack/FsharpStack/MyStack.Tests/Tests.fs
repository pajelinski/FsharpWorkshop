module MyStack =

    type MyStack = MyStack of (int array * int)

    let create capacity = 
        (capacity |> Array.zeroCreate, 0) |> MyStack

    let push item stack =
        let (MyStack (stackArray, index)) = stack
        (index, item) ||>  Array.set stackArray
        (stackArray, index + 1) |> MyStack

    let pop stack = 
        let (MyStack (stackArray, index)) = stack
        (index - 1 |> Array.get stackArray, (stackArray, index - 1) |> MyStack)

module Tests =

    open Xunit

    [<Fact>]
    let ``When pushed 1 It should pop 1`` () =
        let result = 
            1
            |> MyStack.create
            |> MyStack.push 1
            |> MyStack.pop

        Assert.Equal(1, result |> fst)

    [<Fact>]
    let ``When pushed 1 and 2 It should pop 2 and 1`` () =
        let (firstPop, secondPop) = 
            2
            |>MyStack.create
            |> MyStack.push 1
            |> MyStack.push 2 
            |> MyStack.pop 
            |> fun (popedValue, stack) -> (popedValue, stack |> MyStack.pop |> fst)

        Assert.Equal(2, firstPop)
        Assert.Equal(1, secondPop)
