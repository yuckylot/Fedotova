with open('a') as f:
    line = f.readline().split()
    words = []
    for i in line:
        tau_word = i[:]
        word = ""
        for j in range(len(i)):
            if j % 2 == len(i) % 2:
                word += tau_word[0]
                tau_word = tau_word[1:]
            else:
                word += tau_word[-1]
                tau_word = tau_word[:-1]
        words.append("".join(list(reversed(word))))

    words_len = len(words)
    frase = []
    for i in range(words_len):
        if i % 2 == words_len % 2:
            frase.append(words[0])
            words = words[1:]
        else:
            frase.append(words[-1])
            words = words[:-1]
    print("".join(list(reversed(frase))))