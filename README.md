# Farah's Challenge – Old Phone Keypad Decoder
This is my solution to Iron Software’s C# coding challenge.  
The goal was to simulate how an old phone keypad works and translate button sequences into readable text.
---
## 📋 Challenge Summary
The input is a string that simulates key presses on a classic mobile phone keypad.  
Each number corresponds to a group of letters (e.g., 2 = ABC, 3 = DEF).  
- Repeating the same number selects the next letter in the group.  
- A space " " represents a pause between letters.  
- Asterisk "*" acts as backspace.  
- Hash "#" marks the end of the input.
---
## 💡 My Approach
I wrote the code step by step, thinking how I would handle this if I had to decode the message manually.
The main method OldPhonePad(string input) processes the full input string.  
It builds each letter from repeated digits, handles backspaces, and recognizes pauses between letters.
I split some logic into helper methods to keep the main method cleaner:
- One method converts a group of digits into a letter.
- Another maps digits to letters like on a phone keypad.
This is how I would naturally approach the problem as a student: focusing on clarity, logic, and making sure each part works before moving on.
---
---
## 🙌 Final Thoughts
This project was a fun way to put my logic and C# fundamentals into practice.  
I made sure to keep the code clear and easy to follow, as if I were solving it step by step on paper.  
Thanks for the opportunity to show how I approach and solve problems!
---
---
---
P.S. I really enjoyed working on this challenge — it made me think in a very visual and logical way.
As a small twist (if you're up for it, Farah!), try typing your own name using the old phone keypad style.
I'd love to know what key combination you would use — or even how you might approach the logic differently if you had another idea 😊
Thanks again for the opportunity!
