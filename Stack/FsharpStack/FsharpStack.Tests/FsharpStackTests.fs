module MyStackTests 
 
    open Xunit
    
    module MyStack =
        type MyStack = MyStack of int array
        
        let create length = 
            (length, 0) ||> Array.create |> MyStack
            
        let length (stack: MyStack) = 
            stack
            |> fun (MyStack s) -> s
            |> Array.length<int>
    
    [<Fact>]
    let ``Given MyStack with length 1 Length should return 1``() =
        let result = 
            1 
            |> MyStack.create
            |> MyStack.length
        
        Assert.Equal(1, result)
        