# Change Log

## v0.0.0 (current)

Initial

### Block Structure:

Each block contains the following items:

-	Id (int) 
-	nonce  (int)
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
				data: "",
                previous: null
            }
        }
    }
}
```

## how to execute
Everything right now is done with unit tests. See next steps below.

## next steps

- Create Block with data that extends BlockBase. This will probably be a string to start out and then later could be transactions.
- Create console line application that mines x blocks with x difficulty
