using Job_Application.Models;
using Job_Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Job_Application.Data
{
    public class DbSeeder
    {
        private readonly JobApplicationDbContext _context;

        public DbSeeder(JobApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Check if admin already exists
            var adminExists = await _context.Users.AnyAsync(u => u.UserRole == UserRole.Admin);
            
            if (!adminExists)
            {
                // Create default admin account
                PasswordHasher.CreatePasswordHash("Admin@123", out byte[] hash, out byte[] salt);

                var adminUser = new User
                {
                    FirstName = "System",
                    LastName = "Admin",
                    Email = "admin@jobapplication.com",
                    PasswordHash = hash,
                    PasswordSalt = salt,
                    UserRole = UserRole.Admin,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true  // Make sure admin account is active
                };

                _context.Users.Add(adminUser);
                await _context.SaveChangesAsync();

                // Create Admin record
                var admin = new Admin
                {
                    UserId = adminUser.UserId
                };

                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();

                // Seed default FAQs
                await SeedFaqs(admin.AdminId);

                Console.WriteLine("✅ Default admin account created successfully!");
                Console.WriteLine($"   Email: {adminUser.Email}");
                Console.WriteLine("   Password: Admin@123");
                Console.WriteLine("   ⚠️  Please change this password after first login!");
            }
            else
            {
                Console.WriteLine("ℹ️  Admin account already exists. Skipping seed.");
                
                // Check if FAQs exist, if not seed them
                var faqsExist = await _context.FAQs.AnyAsync();
                if (!faqsExist)
                {
                    var existingAdmin = await _context.Admins.FirstAsync();
                    await SeedFaqs(existingAdmin.AdminId);
                }
            }
        }

        private async Task SeedFaqs(int adminId)
        {
            var faqs = new List<FAQ>
            {
                // General FAQs
                new FAQ
                {
                    Question = "What is NextStep?",
                    Answer = "NextStep is a modern platform designed to help individuals and organisations achieve their personal, educational, and professional goals. Whether you are a student, job seeker, or business owner, NextStep provides tools and resources to guide you forward.",
                    Category = FaqCategory.General,
                    DisplayOrder = 1,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Who can use NextStep?",
                    Answer = "Anyone! NextStep is built for students, professionals, small businesses, and institutions that want structured support in planning, tracking, and achieving milestones.",
                    Category = FaqCategory.General,
                    DisplayOrder = 2,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Is NextStep free to use?",
                    Answer = "We offer both free and premium plans. Free gives access to essential tools; premium unlocks advanced features like analytics, personalised recommendations, and additional support.",
                    Category = FaqCategory.General,
                    DisplayOrder = 3,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "How do I create an account?",
                    Answer = "Click on 'Create Account' on the home page, fill in your details, and verify your email. Once verified, you can log in and start using NextStep.",
                    Category = FaqCategory.General,
                    DisplayOrder = 4,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "I forgot my password. What should I do?",
                    Answer = "Go to the 'Forgot Password' link on the login page, enter your registered email, and follow the instructions to reset your password.",
                    Category = FaqCategory.General,
                    DisplayOrder = 5,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Can I use NextStep on mobile devices?",
                    Answer = "Yes! NextStep is fully responsive and can be accessed from smartphones, tablets, and desktops using any modern browser.",
                    Category = FaqCategory.General,
                    DisplayOrder = 6,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "How do I contact support?",
                    Answer = "You can reach out to our support team via email at help@nextstep.co.za or call us at +27 71 686 4997. We typically respond within 24 hours.",
                    Category = FaqCategory.General,
                    DisplayOrder = 7,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "How is my personal information protected?",
                    Answer = "NextStep takes privacy seriously. All personal data is encrypted and securely stored. We comply with relevant data protection regulations.",
                    Category = FaqCategory.General,
                    DisplayOrder = 8,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Are there tutorials or guides?",
                    Answer = "Yes, NextStep provides guides, tutorials, and FAQs to help you navigate the platform efficiently and make the most of the tools available.",
                    Category = FaqCategory.General,
                    DisplayOrder = 9,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Does NextStep offer notifications?",
                    Answer = "Yes! Users receive notifications for new job postings, upcoming deadlines, assessment results, and important platform updates.",
                    Category = FaqCategory.General,
                    DisplayOrder = 10,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Can multiple users share the same account?",
                    Answer = "Each account is intended for a single user. Sharing accounts is not recommended as it may affect your personalised recommendations and security.",
                    Category = FaqCategory.General,
                    DisplayOrder = 11,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "How do I update my profile information?",
                    Answer = "Navigate to your profile page, click 'Edit,' update the necessary details, and save the changes. Your profile information will be immediately updated.",
                    Category = FaqCategory.General,
                    DisplayOrder = 12,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Can I delete my account?",
                    Answer = "Yes, if you decide to leave NextStep, you can delete your account from the settings page. Please note that this action is permanent.",
                    Category = FaqCategory.General,
                    DisplayOrder = 13,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Does NextStep integrate with other platforms?",
                    Answer = "Yes, NextStep can integrate with select job boards, email services, and learning platforms to streamline your workflow.",
                    Category = FaqCategory.General,
                    DisplayOrder = 14,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Can I customize my dashboard?",
                    Answer = "NextStep allows users to customize their dashboard to show relevant tools, upcoming tasks, notifications, and favourite resources.",
                    Category = FaqCategory.General,
                    DisplayOrder = 15,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "How often is new content added?",
                    Answer = "NextStep regularly updates its platform with new resources, guides, assessments, and job opportunities to keep the content relevant and useful.",
                    Category = FaqCategory.General,
                    DisplayOrder = 16,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                
                // Job Seeker FAQs
                new FAQ
                {
                    Question = "Can I track my progress on NextStep?",
                    Answer = "Absolutely! NextStep provides tools to track your learning, applications, and career milestones so you can monitor your growth over time.",
                    Category = FaqCategory.JobSeekers,
                    DisplayOrder = 1,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Are there assessments available?",
                    Answer = "Yes, NextStep provides various assessments for job readiness, skill evaluation, and career planning to help users understand their strengths and areas for improvement.",
                    Category = FaqCategory.JobSeekers,
                    DisplayOrder = 2,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                
                // Employer FAQs
                new FAQ
                {
                    Question = "Can employers post jobs on NextStep?",
                    Answer = "Yes! Employers can create accounts, post job listings, and manage applications directly through the platform.",
                    Category = FaqCategory.Employers,
                    DisplayOrder = 1,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                },
                new FAQ
                {
                    Question = "Is there customer support for businesses?",
                    Answer = "Yes, businesses and institutions have dedicated support channels to assist with onboarding, account management, and troubleshooting.",
                    Category = FaqCategory.Employers,
                    DisplayOrder = 2,
                    IsPublished = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                }
            };

            await _context.FAQs.AddRangeAsync(faqs);
            await _context.SaveChangesAsync();
            
            Console.WriteLine($"✅ {faqs.Count} FAQs seeded successfully!");
        }
    }
}
