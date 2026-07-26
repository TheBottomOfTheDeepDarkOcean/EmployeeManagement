
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesManagement.Models;
using EmployeesManagement.Data;

public class AuditsController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuditsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: AUDITS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.AuditLogs.ToListAsync());
    }

    // GET: AUDITS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var audit = await _context.AuditLogs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (audit == null)
        {
            return NotFound();
        }

        return View(audit);
    }

    // GET: AUDITS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AUDITS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UserId,AuditType,TableName,Dateime,OldValues,NewValues,AffectedColumns,PrimaryKey")] Audit audit)
    {
        if (ModelState.IsValid)
        {
            _context.Add(audit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(audit);
    }

    // GET: AUDITS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var audit = await _context.AuditLogs.FindAsync(id);
        if (audit == null)
        {
            return NotFound();
        }
        return View(audit);
    }

    // POST: AUDITS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,UserId,AuditType,TableName,Dateime,OldValues,NewValues,AffectedColumns,PrimaryKey")] Audit audit)
    {
        if (id != audit.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(audit);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuditExists(audit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(audit);
    }

    // GET: AUDITS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var audit = await _context.AuditLogs
            .FirstOrDefaultAsync(m => m.Id == id);
        if (audit == null)
        {
            return NotFound();
        }

        return View(audit);
    }

    // POST: AUDITS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var audit = await _context.AuditLogs.FindAsync(id);
        if (audit != null)
        {
            _context.AuditLogs.Remove(audit);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AuditExists(int? id)
    {
        return _context.AuditLogs.Any(e => e.Id == id);
    }
}
