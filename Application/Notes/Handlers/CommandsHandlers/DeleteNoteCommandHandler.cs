using Application.Common.Exceptions;
using Application.Interfaces;
using Application.NoteBooks.Commands;
using Application.Notes.Commands;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteBooks.Handlers;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly IWorkBookDbContext _dbContext;

    public DeleteNoteCommandHandler(IWorkBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken ct)
    {
        var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (note == null)
        {
            throw new NotFoundException(nameof(NoteBook), request.Id);
        }

        _dbContext.Notes.Remove(note);

        return Unit.Value;
    }

}