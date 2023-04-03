using Interface;

List<IAnimal> animals = new List<IAnimal>();
animals.Add(new Dog());
animals.Add(new Cat());

foreach (var animal in animals)
{
    animal.MakeSound();
    animal.Move();

    switch(animal)
    {
        case Dog dog:
            dog.eat();
            break;
        case Cat cat:
            cat.Scratch();
            break;
    }       
}