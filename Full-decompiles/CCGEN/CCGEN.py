# Decompiled with PyLingual (https://pylingual.io)
# Internal filename: CCGEN.py
# Bytecode version: 3.10.0rc2 (3439)
# Source timestamp: 1970-01-01 00:00:00 UTC (0)

import random
import os
import time
G = '\x1b[32m'
E = '\x1b[0m]'

def generate_number(prefix):
    print('\n-------------------------------------------------------------------------------------------\n')
    random_digits = ''.join([str(random.randint(0, 9)) for _ in range(10)])
    full_number = f'{prefix}{random_digits}'
    month = random.randint(1, 12)
    month_str = f'{month:02d}'
    random_25_30 = random.randint(25, 30)
    three_digits = random.randint(100, 999)
    return f'{full_number}\n{month_str}{random_25_30}\n{three_digits}'

def main():
    while True:
        print(G + '-------------------------------------------------------------------------------------------')
        print('\n\n     __________  __________  __________   _________    ____  ____     _____________   __   \n    / ____/ __ \\/ ____/ __ \\/  _/_  __/  / ____/   |  / __ \\/ __ \\   / ____/ ____/ | / /   \n   / /   / /_/ / __/ / / / // /  / /    / /   / /| | / /_/ / / / /  / / __/ __/ /  |/ /    \n  / /___/ _, _/ /___/ /_/ // /  / /    / /___/ ___ |/ _, _/ /_/ /  / /_/ / /___/ /|  /     \n  \\____/_/ |_/_____/_____/___/ /_/     \\____/_/  |_/_/ |_/_____/   \\____/_____/_/ |_/      \n                                                                                         \n\n')
        print('-------------------------------------------------------------------------------------------')
        print('\n1. ランダムなクレジットカードの番号を作成する\n')
        print('\n2. ツールのバージョン\n')
        print('\n3. ツールの情報\n')
        print('\n4. ツールの終了\n')
        choice = input('\n選択してください: ')
        if choice == '1':
            save_path = input('\n情報の保存先のパスを指定しますか？ (Y/N): ').strip().upper()
            if save_path == 'Y':
                path = input('\n保存先のパスを入力してください: ').strip()
            else:
                path = None
            num_times = int(input('\n生成数(無制限): '))
            interval = float(input('\n生成する間隔(秒単位 : 推奨 1)を入力してください: '))
            print('\n-------------------------------------------------------------------------------------------\n')
            print('\n生成可能なランダムのクレジットカード')
            print('\n-------------------------------------------------------------------------------------------')
            print('\n1. 470883[三井住友カード]\n')
            print('\n2. 464988[PayPay銀行]\n')
            print('\n3. 429769[楽天カード]\n')
            print('\n4. 420523[AEON-VISA]\n')
            print('\n5. 525215[SAISON-MASTER]\n')
            print('\n6. 520330[三井住友カード(G)]\n')
            print('\n7. ランダムで生成する\n')
            prefix_choice = input('\n選択してください: ')
            prefixes = {'1': '470883', '2': '464988', '3': '429769', '4': '420523', '5': '525215', '6': '520330'}
            if prefix_choice in prefixes or prefix_choice == '7':
                results = []
                for _ in range(num_times):
                    if prefix_choice == '7':
                        prefix = random.choice(list(prefixes.values()))
                    else:
                        prefix = prefixes[prefix_choice]
                    result = generate_number(prefix)
                    results.append(result)
                    print(result + '\n')
                    time.sleep(interval)
                if path:
                    with open(path, 'w') as file:
                        for result in results:
                            file.write(result + '\n\n')
                    print(f'\n結果が {path} に保存されました。\n')
                    input('press the key....')
            else:
                print('\n無効な選択です。\n')
                input('press the key....')
        elif choice == '2':
            print('\nバージョン: 1.0\n 制作者 : st.xd \n Discord : ELEFTHERIA \n')
            input('press the key....')
        elif choice == '3':
            print('\nツールのご利用をしてくださり、誠にありがとうございます。\nこのツールは実際に使用できるクレジットカードを作成するモノではありません。\n未確認のクレジットカードを販売する業者用のツールと言ってもいいでしょう。 \n制作者 : st.xd \nDiscord : ELEFTHERIA \n')
            input('press the key....')
        else:
            if choice == '4':
                print('\n終了します。\n')
                return
            print('\n無効な選択です。\n')
        input('press the key....')
        os.system('cls' if os.name == 'nt' else 'clear')
if __name__ == '__main__':
    main()