# BlockchainHelloWorld
Playground to create a blockchain data structure. This is very much a trial and error project and commits will reflect that.


## Change Log

### v0 (current)

Each block contains the following items:

-	Id (int) 
-	nonce  (int)
-	previousBlock (Block)

Each block then nests inside of itself creating a json like structure similar to:
```
{
    id: 3,
    nonce: 0,
    previous: {
        id: 2,
        nonce: 0,
        previous: {
            id: 1,
            nonce: 0,
            previous: null
        }
    }
}
```

#### how to execute
Everything right now is done with unit tests. See next steps below.

#### next steps

- Create Block with data that extends BlockBase. This will probably be a string to start out and then later could be transactions.
- Create console line application that mines x blocks with x difficulty


## References

### Overall

- [Blockchain Demo](https://anders.com/blockchain/)

### Code

Code references are listed as comments inline
