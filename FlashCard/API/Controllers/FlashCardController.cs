using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FlashCardController : ControllerBase
{
    private readonly Services.FlashCardServices _service;
    public FlashCardController(Services.FlashCardServices service){
        _service = service;
    }

//Get card by ID
    [HttpGet]
    [Route("card/{id:int}")]
    public Flashcard GetCardById(int id){
        return _service.GetCardById(id);
    }

//Get all flashcards
    [HttpGet]
    [Route("cards")]
    public List<Flashcard> GetAllCards(){
        return _service.GetAllCards();
    }

//Create new flash card

    [HttpPost]
    [Route("card/create")]
    public List<Flashcard> Create(Flashcard flash){
        _service.CreateCard(flash);
        return _service.GetAllCards();    
    }

//Update flash card
    [HttpPut]
    [Route("card/update/{id:int}")]
    public Flashcard UpdateCard(int id){
        return _service.UpdateCard(id);
    }

//Remove a flash card
    [HttpDelete]
    [Route("card/Delete/{id:int}")]
    public Flashcard DeleteCard(int id){
        return _service.DeleteCard(id);
    }

}
