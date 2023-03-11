using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RDS_Commerce.Business.Interfaces.RepositoryContracts;
using RDS_Commerce.Domain.Arguments;
using RDS_Commerce.Domain.Entities;
using RDS_Commerce.Infrastructure.ORM.ContextSettings;
using RDS_Commerce.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace RDS_Commerce.Infrastructure.Repository;
public sealed class AccountIdentityRepository : BaseRepository<AccountIdentity>, IAccountIdentityRepository
{
    private readonly UserManager<AccountIdentity> _userManager;
    private readonly SignInManager<AccountIdentity> _signInManager;

    public AccountIdentityRepository(RdsApplicationDbContext context,
                                     UserManager<AccountIdentity> userManager,
                                     SignInManager<AccountIdentity> signInManager) 
        : base(context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<AccountIdentity?> FindByPredicateAsync(Expression<Func<AccountIdentity, bool>> where, bool asNoTracking = false)
    {
        IQueryable<AccountIdentity> query = _dbSetContext;

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(where);
    }

    public async Task<IdentityResult> CreateAccountAsync(AccountIdentity entity) =>
        await _userManager.CreateAsync(entity, entity.PasswordHash!);

    public async Task<IdentityResult> UpdateIdentityAsync(AccountIdentity accountIdentity) =>
        await _userManager.UpdateAsync(accountIdentity);

    public async Task<string> GenerateForgotPasswordTokenAsync(AccountIdentity entity) =>
        await _userManager.GeneratePasswordResetTokenAsync(entity);

    public async Task<IdentityResult> ResetPasswordAsync(ResetPassword resetPassword) =>
        await _userManager.ResetPasswordAsync(resetPassword.AccountIdentity, resetPassword.Token, resetPassword.Password);

    public async Task<SignInResult> SignPasswordAsync(string login, string password) =>
        await _signInManager.PasswordSignInAsync(login, password, false, false);
}
