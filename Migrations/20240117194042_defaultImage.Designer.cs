﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebCookingBook.DbContexts;

#nullable disable

namespace WebCookingBook.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240117194042_defaultImage")]
    partial class defaultImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("WebCookingBook.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NameCategory = "first"
                        },
                        new
                        {
                            Id = 2,
                            NameCategory = "second"
                        },
                        new
                        {
                            Id = 3,
                            NameCategory = "third"
                        },
                        new
                        {
                            Id = 4,
                            NameCategory = "fourth"
                        });
                });

            modelBuilder.Entity("WebCookingBook.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameIngredient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Units")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 1,
                            NameIngredient = "First",
                            RecipeId = 1,
                            Units = 1
                        });
                });

            modelBuilder.Entity("WebCookingBook.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Image = "main_default.jpg",
                            Name = "first"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Image = "main_default.jpg",
                            Name = "second"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Image = "main_default.jpg",
                            Name = "third"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Image = "main_default.jpg",
                            Name = "fourth"
                        });
                });

            modelBuilder.Entity("WebCookingBook.Models.StepCook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberStep")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("StepCooks");
                });

            modelBuilder.Entity("WebCookingBook.Models.Ingredient", b =>
                {
                    b.HasOne("WebCookingBook.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("WebCookingBook.Models.Recipe", b =>
                {
                    b.HasOne("WebCookingBook.Models.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebCookingBook.Models.StepCook", b =>
                {
                    b.HasOne("WebCookingBook.Models.Recipe", "Recipe")
                        .WithMany("StepsCooking")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("WebCookingBook.Models.Category", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("WebCookingBook.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("StepsCooking");
                });
#pragma warning restore 612, 618
        }
    }
}
