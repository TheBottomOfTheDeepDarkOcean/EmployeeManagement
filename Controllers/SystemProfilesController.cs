
using EmployeesManagement.Data;
using EmployeesManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class SystemProfilesController : Controller
{
    private readonly ApplicationDbContext _context;

    public SystemProfilesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: SYSTEMPROFILES
    public async Task<IActionResult> Index()
    {
        return View(await _context.SystemProfiles.ToListAsync());
    }

    // GET: SYSTEMPROFILES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var systemprofile = await _context.SystemProfiles
            .FirstOrDefaultAsync(m => m.Id == id);
        if (systemprofile == null)
        {
            return NotFound();
        }

        return View(systemprofile);
    }

    // GET: SYSTEMPROFILES/Create
    public IActionResult Create()
    {
        ViewData["ProfileId"] = new SelectList(_context.SystemProfiles, "Id", "Name");
        return View();
    }

    // POST: SYSTEMPROFILES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SystemProfile systemprofile)
    {
        systemprofile.CreatedById = "CielSs";
        systemprofile.CreatedOn = DateTime.Now;
        _context.Add(systemprofile);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
        ViewData["ProfileId"] = new SelectList(_context.SystemProfiles, "Id", "Name", systemprofile.ProfileId);
        return View(systemprofile);
    }

    // GET: SYSTEMPROFILES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var systemprofile = await _context.SystemProfiles.FindAsync(id);
        if (systemprofile == null)
        {
            return NotFound();
        }
        return View(systemprofile);
    }

    // POST: SYSTEMPROFILES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,ProfileId,Profile,Children,Order,CreatedById,CreatedOn,ModifiedById,ModifiedOn")] SystemProfile systemprofile)
    {
        if (id != systemprofile.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(systemprofile);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemProfileExists(systemprofile.Id))
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
        return View(systemprofile);
    }

    // GET: SYSTEMPROFILES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var systemprofile = await _context.SystemProfiles
            .FirstOrDefaultAsync(m => m.Id == id);
        if (systemprofile == null)
        {
            return NotFound();
        }

        return View(systemprofile);
    }

    // POST: SYSTEMPROFILES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var systemprofile = await _context.SystemProfiles.FindAsync(id);
        if (systemprofile != null)
        {
            _context.SystemProfiles.Remove(systemprofile);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SystemProfileExists(int? id)
    {
        return _context.SystemProfiles.Any(e => e.Id == id);
    }
}
