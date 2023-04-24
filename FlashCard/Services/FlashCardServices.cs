using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class FlashCardServices{
    private readonly FlashCardDbContext _context;

//using dependency injection for FlashCardDbContext
    public FlashCardServices(FlashCardDbContext context){
        _context = context;
    }

//Creating logic for adding a flashcard
    public Flashcard CreateCard(Flashcard flash){
        _context.Add(flash);

        _context.SaveChanges();

        return flash;

    }

//Getting a list of all flashcards
    public List<Flashcard> GetAllCards(){
        return _context.Flashcards.ToList();
    }

//Getting Flash card by id

    public Flashcard GetCardById(int id){
        return _context.Flashcards.FirstOrDefault(w => w.Id == id)!;
    }


//Updating a card by Id
    public Flashcard UpdateCard(int id){
        Flashcard card = GetCardById(id);
        _context.Update(card);
        _context.SaveChanges();
        return card;
    }

//Delete a card by Id
    public Flashcard DeleteCard(int id){
        Flashcard card = GetCardById(id);
        _context.Remove(card);
        return card;
    }

}