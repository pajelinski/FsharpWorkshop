module MyStackTests

    open Xunit

    [<Fact>]
    let ``Given capacit 1 it shold create stack of size 1`` () =
        let result =
            1
            |> MyStack.create
            |> MyStack.size

        Assert.Equal(1, result)

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
        let stack = 
            2
            |> MyStack.create
            |> MyStack.push 1
            |> MyStack.push 2 

        let (firstPop, newStack) = stack |> MyStack.pop 
        let (secondPop, _) = newStack |> MyStack.pop 

        Assert.Equal(2, firstPop)
        Assert.Equal(1, secondPop)

    [<Fact>]
    let ``Given capacity 0 when pushed second value on stack it should throw MyStackOverflowException `` () =
        Assert.Throws<MyStack.MyStackOverflowException>(fun () -> 0 |> MyStack.create |> MyStack.push 1 |> ignore) |> ignore

    [<Fact>]
    let ``Given empty stack when pushed second value on stack it should throw MyStackUnderflowException `` () =
        Assert.Throws<MyStack.MyStackUnderflowException>(fun () -> 1 |> MyStack.create |> MyStack.pop |> ignore) |> ignore

    let ``Given negative capacity it should throw System.ArgumentException() `` () =
        Assert.Throws<System.ArgumentException>(fun () -> -1 |> MyStack.create |> MyStack.pop |> ignore) |> ignore
