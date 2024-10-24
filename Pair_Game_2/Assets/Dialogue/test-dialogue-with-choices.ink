-> main

=== main ===
Well, hello, beautiful. What's your name?
+ [Billy]
    ->named("Billy")
+ [Bob]
    -> named("Bob")
+ [Joe]
    -> named("Joe")

=== named(name) ===
{name}... What a lovely name. 
    -> nice(name)
    
=== nice(name) ===
Tell me, {name}- do you think I look nice today?
+ [Yes]
    Oh, naturally. I am the very essence of beauty.
        -> bye
+ [No]
    What, really? Take another look.
        -> nice(name)

=== bye ===
It was nice chatting with you. I'll be seeing you later, now.
+ [Bye!]
Yes, yes. Take care.
    ->END