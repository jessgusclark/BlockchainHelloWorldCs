# BlockchainHelloWorld
Playground to create a blockchain data structure. This is very much a trial and error project and commits will reflect that.


## Current Version: v0.0.1

Added data sub method that holds a string, such as "Hello World!"

### Block Structure:

Each block contains the following items:

-	Id (int) 
-	nonce  (int)
-	data (string)
-	previousBlock (Block)

### Blockchain Structure:

Each block then nests inside of itself creating a json like structure similar to:
```
{
    id: 3,
    nonce: 22,
    data: "Hello World 3!",
    previous: {
        id: 2,
        nonce: 20,
        data: "Hello World 2!",
        previous: {
            id: 1,
            nonce: 17,
            data: "Hello World 1!",
            previous: {
                id: 0,
                nonce: 0,
                data: "Hello Genesis Block!",
                previous: null
            }
        }
    }
}
```

### how to execute
Everything right now is done with unit tests. See next steps below.

### next steps

- Create console line application that mines x blocks with x difficulty

[Previous Versions](CHANGELOG.md)

## References

### Overall

- [Blockchain Demo](https://anders.com/blockchain/) - this got me thinking about the structure and how it works.

### Code

Code references are listed as comments inline
