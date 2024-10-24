-> main

=== main ===
Well, hello, beautiful. What's your name? #portrait:test-smirk
+ [Billy]
    ->named("Billy")
+ [Bob]
    -> named("Bob")
+ [Joe]
    -> named("Joe")

=== named(name) ===
{name}... What a lovely name. #portrait:test-happy
    -> nice(name)
    
=== nice(name) ===
Tell me, {name}- do you think I look nice today? #portrait:test-happy
+ [Yes]
    Oh, naturally. I am the very essence of beauty. #portrait:test-smirk
        -> bye
+ [No]
    What, really? Take another look. #portrait:test-offend
        -> nice(name)

=== bye ===
It was nice chatting with you. I'll be seeing you later, now. #portrait:test-happy
+ [Bye!]
Yes, yes. Take care.
    ->END